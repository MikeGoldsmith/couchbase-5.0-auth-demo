using System;
using System.Configuration;
using Couchbase;
using Couchbase.Authentication;
using Couchbase.Core;

namespace couchbase_5._0_auth_demo.Helpers
{
    public static class CouchHelper
    {
        private static readonly Lazy<Cluster> Cluster = new Lazy<Cluster>(SetupCluster);

        private static Cluster SetupCluster()
        {
            // create cluster from config
            var cluster = new Cluster("couchbaseClients/couchbase");

            // get username and password from config then authenticate
            var username = ConfigurationManager.AppSettings.Get("couchbase_username");
            var password = ConfigurationManager.AppSettings.Get("couchbase_password");
            cluster.Authenticate(new PasswordAuthenticator(username, password));

            return cluster;
        }

        public static IBucket GetBucket(string bucketName)
        {
            return Cluster.Value.OpenBucket(bucketName);
        }
    }
}
