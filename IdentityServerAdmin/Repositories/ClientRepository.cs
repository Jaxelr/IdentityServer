using IdentityServerAdmin.Models;
using Insight.Database;
using Insight.Database.Providers.MsSqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace IdentityServerAdmin.Repositories
{
    public class ClientRepository : IDisposable
    {
        private readonly DbConnection connection;

        public ClientRepository(DbConnection connection)
        {
            this.connection = connection;
            SqlInsightDbProvider.RegisterProvider();

            if (this.connection.State == System.Data.ConnectionState.Closed)
                this.connection.Open();
        }

        public async Task<IList<Client>> GetClients(int id = 0, string name = null) =>
            await connection.QueryAsync<Client>("GetClients", new { id, name })
            .ConfigureAwait(false);

        public async Task<int> StoreClient(Client client) =>
            await connection.SingleAsync<int>("StoreClient", client)
            .ConfigureAwait(false);

        public async Task<IList<ClientScope>> GetClientScopes(int id = 0, int clientId = 0, string scope = null) =>
            await connection.QueryAsync<ClientScope>("GetClientScopes", new { id, clientId, scope })
            .ConfigureAwait(false);

        public async Task<int> StoreClientScope(ClientScope scope) =>
            await connection.SingleAsync<int>("StoreClientScope", scope )
            .ConfigureAwait(false);

        public async Task<int> DeleteClientScope(int id) =>
            await connection.SingleAsync<int>("DeleteClientScope", new { id })
            .ConfigureAwait(false);

        public void Dispose()
        {
            connection?.Close();
            connection?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
