using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using IdentityServerAdmin.Models;
using Insight.Database;

namespace IdentityServerAdmin.Repositories
{
    public class ApiRepository : IDisposable
    {
        private readonly DbConnection connection;

        public ApiRepository(DbConnection connection)
        {
            this.connection = connection;
            SqlInsightDbProvider.RegisterProvider();

            if (this.connection.State == System.Data.ConnectionState.Closed)
                this.connection.Open();
        }

        public async Task<IList<Api>> GetApiResources(int id = 0, string name = null) =>
            await connection.QueryAsync<Api>("GetApiResources", new { id, name })
            .ConfigureAwait(false);

        public async Task<int> StoreApiResource(Api resource) =>
            await connection.SingleAsync<int>("StoreApiResource", resource)
            .ConfigureAwait(false);

        public async Task<IList<ApiScope>> GetApiScopes(int id = 0, string name = null, int apiResourceId = 0) =>
            await connection.QueryAsync<ApiScope>("GetApiScopes", new { id, name, apiResourceId })
            .ConfigureAwait(false);

        public async Task<int> StoreApiScope(ApiScope scope) =>
            await connection.SingleAsync<int>("StoreApiScope", scope)
            .ConfigureAwait(false);

        public async Task<int> DeleteApiScope(int id) =>
            await connection.SingleAsync<int>("DeleteApiScope", new { id })
            .ConfigureAwait(false);

        public void Dispose()
        {
            connection?.Close();
            connection?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
