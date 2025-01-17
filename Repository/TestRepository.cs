using InterfaceTestingDocument_Api.Models;
using Microsoft.Data.SqlClient;

namespace InterfaceTestingDocument_Api.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly string _connectionString;
        public TestRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> SaveTestData(SRTestRequest request)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                using (var transaction = await con.BeginTransactionAsync())
                {
                    try
                    {
                        var insertQuery = "INSERT INTO TestResults (LotSnCode, StationCode, FailureReason, WorkCenter, IsPass, OrderNo, TestFrameidNo) " +
                                          "OUTPUT INSERTED.Id " + // Capture the inserted Id
                                          "VALUES (@LotSnCode, @StationCode, @FailureReason, @WorkCenter, @IsPass, @OrderNo, @TestFrameidNo)";

                        int testResultId;

                        using (var command = new SqlCommand(insertQuery, con, (SqlTransaction)transaction))
                        {

                            command.Parameters.AddWithValue("@LotSnCode", request.LotSnCode);
                            command.Parameters.AddWithValue("@StationCode", request.StationCode);
                            command.Parameters.AddWithValue("@FailureReason", (object)request.FailureReason ?? DBNull.Value);
                            command.Parameters.AddWithValue("@WorkCenter", request.WorkCenter);
                            command.Parameters.AddWithValue("@IsPass", request.IsPass);
                            command.Parameters.AddWithValue("@OrderNo", request.OrderNo);
                            command.Parameters.AddWithValue("@TestFrameidNo", request.TestFrameidNo);

                            testResultId = (int)await command.ExecuteScalarAsync();
                            if (testResultId <= 0)
                            {
                                throw new Exception("Failed to insert SRTestRequest and retrieve TestRequestId.");
                            }
                        }

                        foreach (var testItem in request.TestItems)
                        {
                            var insertItemQuery = "INSERT INTO TestItems (TestResultId, ItemName, ItemResult, ItemStartTime, ItemEndTime, ItemDuration) " +
                                                  "VALUES (@TestResultId, @ItemName, @ItemResult, @ItemStartTime, @ItemEndTime, @ItemDuration)";

                            using (var command = new SqlCommand(insertItemQuery, con, (SqlTransaction)transaction))
                            {
                                command.Parameters.AddWithValue("@TestResultId", testResultId);
                                command.Parameters.AddWithValue("@ItemName", testItem.ItemName);
                                command.Parameters.AddWithValue("@ItemResult", testItem.ItemResult);
                                command.Parameters.AddWithValue("@ItemStartTime", testItem.ItemStartTime);
                                command.Parameters.AddWithValue("@ItemEndTime", testItem.ItemEndTime);
                                command.Parameters.AddWithValue("@ItemDuration", (object)testItem.ItemDuration ?? DBNull.Value);

                                await command.ExecuteNonQueryAsync();
                            }
                        }
                        await transaction.CommitAsync();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        return false;
                    }
                }
            }
        }
    }
}
