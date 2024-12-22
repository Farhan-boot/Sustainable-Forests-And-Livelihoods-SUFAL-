using System.Text.Json;

using PTSL.GENERIC.Web.Core.Helper;

namespace PTSL.GENERIC.Web.Core.Services.Implementation.Migrations;

public class MigrationService
{
    public MigrationService()
    {
    }

    public async Task<IEnumerable<MigrateResult>> MeetingMigration(IFormFile excelFile, bool shouldMigrate)
    {
        var apiUrl = $"{URLHelper.ApiBaseURL.Replace("api/", "")}Meeting-Migration-Web/{shouldMigrate}";

        try
        {
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(60);
            using var formData = new MultipartFormDataContent();
            using var fileContent = new StreamContent(excelFile.OpenReadStream());
            formData.Add(fileContent, nameof(excelFile), excelFile.FileName);

            var response = await httpClient.PostAsync(apiUrl, formData);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonSerializer.Deserialize<IEnumerable<MigrateResult>>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                }) ?? Enumerable.Empty<MigrateResult>();

                return result;
            }

            return Enumerable.Empty<MigrateResult>();
        }
        catch (Exception ex)
        {
            return new List<MigrateResult>
            {
                new MigrateResult
                {
                    Message = ex.Message,
                }
            };
        }
    }

    public async Task<IEnumerable<MigrateResult>> AIGDataMigration(IFormFile excelFile, bool shouldMigrate)
    {
        var apiUrl = $"{URLHelper.ApiBaseURL.Replace("api/", "")}AIG-Data-Migration-Web/{shouldMigrate}";

        try
        {
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(60);
            using var formData = new MultipartFormDataContent();
            using var fileContent = new StreamContent(excelFile.OpenReadStream());
            formData.Add(fileContent, nameof(excelFile), excelFile.FileName);

            var response = await httpClient.PostAsync(apiUrl, formData);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonSerializer.Deserialize<IEnumerable<MigrateResult>>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                }) ?? Enumerable.Empty<MigrateResult>();

                return result;
            }

            return Enumerable.Empty<MigrateResult>();
        }
        catch (Exception ex)
        {
            return new List<MigrateResult>
            {
                new MigrateResult
                {
                    Message = ex.Message,
                }
            };
        }
    }

    public async Task<IEnumerable<MigrateResult>> CIPDataMigration(IFormFile excelFile, bool shouldMigrate)
    {
        var apiUrl = $"{URLHelper.ApiBaseURL.Replace("api/", "")}cip-list-for-web/{shouldMigrate}";

        try
        {
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(60);
            using var formData = new MultipartFormDataContent();
            using var fileContent = new StreamContent(excelFile.OpenReadStream());
            formData.Add(fileContent, nameof(excelFile), excelFile.FileName);

            var response = await httpClient.PostAsync(apiUrl, formData);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonSerializer.Deserialize<IEnumerable<MigrateResult>>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                }) ?? Enumerable.Empty<MigrateResult>();

                return result;
            }

            return Enumerable.Empty<MigrateResult>();
        }
        catch (Exception ex)
        {
            return new List<MigrateResult>
            {
                new MigrateResult
                {
                    Message = ex.Message,
                }
            };
        }
    }

    public async Task<IEnumerable<MigrateResult>> CommunityTraining(IFormFile excelFile, bool shouldMigrate)
    {
        var apiUrl = $"{URLHelper.ApiBaseURL.Replace("api/", "")}community-training-migrate-web/{shouldMigrate}";

        try
        {
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(60);
            using var formData = new MultipartFormDataContent();
            using var fileContent = new StreamContent(excelFile.OpenReadStream());
            formData.Add(fileContent, nameof(excelFile), excelFile.FileName);

            var response = await httpClient.PostAsync(apiUrl, formData);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonSerializer.Deserialize<IEnumerable<MigrateResult>>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                }) ?? Enumerable.Empty<MigrateResult>();

                return result;
            }

            return Enumerable.Empty<MigrateResult>();
        }
        catch (Exception ex)
        {
            return new List<MigrateResult>
            {
                new MigrateResult
                {
                    Message = ex.Message,
                }
            };
        }
    }

    public async Task<IEnumerable<MigrateResult>> CommitteeMigration(IFormFile excelFile, bool shouldMigrate)
    {
        var apiUrl = $"{URLHelper.ApiBaseURL.Replace("api/", "")}committee-data-migration-web/{shouldMigrate}";

        try
        {
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(60);
            using var formData = new MultipartFormDataContent();
            using var fileContent = new StreamContent(excelFile.OpenReadStream());
            formData.Add(fileContent, nameof(excelFile), excelFile.FileName);

            var response = await httpClient.PostAsync(apiUrl, formData);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonSerializer.Deserialize<IEnumerable<MigrateResult>>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                }) ?? Enumerable.Empty<MigrateResult>();

                return result;
            }

            return Enumerable.Empty<MigrateResult>();
        }
        catch (Exception ex)
        {
            return new List<MigrateResult>
            {
                new MigrateResult
                {
                    Message = ex.Message,
                }
            };
        }
    }

    public async Task<IEnumerable<MigrateResult>> PatrollingMigration(IFormFile excelFile, bool shouldMigrate)
    {
        var apiUrl = $"{URLHelper.ApiBaseURL.Replace("api/", "")}patrolling-migration-web/{shouldMigrate}";

        try
        {
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(60);
            using var formData = new MultipartFormDataContent();
            using var fileContent = new StreamContent(excelFile.OpenReadStream());
            formData.Add(fileContent, nameof(excelFile), excelFile.FileName);

            var response = await httpClient.PostAsync(apiUrl, formData);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonSerializer.Deserialize<IEnumerable<MigrateResult>>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                }) ?? Enumerable.Empty<MigrateResult>();

                return result;
            }

            return Enumerable.Empty<MigrateResult>();
        }
        catch (Exception ex)
        {
            return new List<MigrateResult>
            {
                new MigrateResult
                {
                    Message = ex.Message,
                }
            };
        }
    }

    public async Task<IEnumerable<MigrateResult>> LaborMigration(IFormFile excelFile, bool shouldMigrate)
    {
        var apiUrl = $"{URLHelper.ApiBaseURL.Replace("api/", "")}labor-migration-web/{shouldMigrate}";

        try
        {
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(60);
            using var formData = new MultipartFormDataContent();
            using var fileContent = new StreamContent(excelFile.OpenReadStream());
            formData.Add(fileContent, nameof(excelFile), excelFile.FileName);

            var response = await httpClient.PostAsync(apiUrl, formData);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonSerializer.Deserialize<IEnumerable<MigrateResult>>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                }) ?? Enumerable.Empty<MigrateResult>();

                return result;
            }

            return Enumerable.Empty<MigrateResult>();
        }
        catch (Exception ex)
        {
            return new List<MigrateResult>
            {
                new MigrateResult
                {
                    Message = ex.Message,
                }
            };
        }
    }


    public async Task<IEnumerable<MigrateResult>> TransactionOnCdfMigration(IFormFile excelFile, bool shouldMigrate)
    {
        var apiUrl = $"{URLHelper.ApiBaseURL.Replace("api/", "")}TransactionOnCdf-list-for-web/{shouldMigrate}";

        try
        {
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(60);
            using var formData = new MultipartFormDataContent();
            using var fileContent = new StreamContent(excelFile.OpenReadStream());
            formData.Add(fileContent, nameof(excelFile), excelFile.FileName);

            var response = await httpClient.PostAsync(apiUrl, formData);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonSerializer.Deserialize<IEnumerable<MigrateResult>>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                }) ?? Enumerable.Empty<MigrateResult>();

                return result;
            }

            return Enumerable.Empty<MigrateResult>();
        }
        catch (Exception ex)
        {
            return new List<MigrateResult>
            {
                new MigrateResult
                {
                    Message = ex.Message,
                }
            };
        }
    }

    public async Task<IEnumerable<MigrateResult>> IndividualLDF(IFormFile excelFile, bool shouldMigrate)
    {
        var apiUrl = $"{URLHelper.ApiBaseURL.Replace("api/", "")}individualLDF/migrate/{shouldMigrate}";

        try
        {
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(60);
            using var formData = new MultipartFormDataContent();
            using var fileContent = new StreamContent(excelFile.OpenReadStream());
            formData.Add(fileContent, nameof(excelFile), excelFile.FileName);

            var response = await httpClient.PostAsync(apiUrl, formData);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var result = JsonSerializer.Deserialize<IEnumerable<MigrateResult>>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                }) ?? Enumerable.Empty<MigrateResult>();

                return result;
            }

            return Enumerable.Empty<MigrateResult>();
        }
        catch (Exception ex)
        {
            return new List<MigrateResult>
            {
                new MigrateResult
                {
                    Message = ex.Message,
                }
            };
        }
    }
}

public class MigrateResult
{
    public double SerialNo { get; set; }
    public string Value { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}

