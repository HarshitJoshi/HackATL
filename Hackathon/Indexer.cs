/*private static async Task createIndexers() {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appSettings.json");
            IConfigurationRoot configuration = builder.Build();

            SearchServiceClient searchService = new SearchServiceClient(
                searchServiceName: configuration["SearchServiceName"],
                credentials: new SearchCredentials(configuration["SearchServiceAdminApiKey"]));

            Console.WriteLine("Creating index...");
            Index index = new Index(
                name: "tags",
                fields: FieldBuilder.BuildForType<Tags>());
            bool exists = await searchService.Indexes.ExistsAsync(index.Name);
            if (exists) {
                await searchService.Indexes.DeleteAsync(index.Name);
            }
            await searchService.Indexes.CreateAsync(index);

            Console.WriteLine("Creating data source...");

            DataSource dataSource = DataSource.AzureSql(
                name: "azure-sql",
                sqlConnectionString: configuration["AzureSQLConnectionString"],
                tableOrViewName: "Images",
                deletionDetectionPolicy: new SoftDeleteColumnDeletionDetectionPolicy(
                    softDeleteColumnName: "IsDeleted",
                    softDeleteMarkerValue: "true"));
            dataSource.DataChangeDetectionPolicy = new SqlIntegratedChangeTrackingPolicy();
            // The data source does not need to be deleted if it was already created,
            // but the connection string may need to be updated if it was changed
            await searchService.DataSources.CreateOrUpdateAsync(dataSource);

            Console.WriteLine("Creating Azure SQL indexer...");
            Indexer indexer = new Indexer(
                name: "azure-sql-indexer",
                dataSourceName: dataSource.Name,
                targetIndexName: index.Name,
                schedule: new IndexingSchedule(TimeSpan.FromDays(1)));
            // Indexers contain metadata about how much they have already indexed
            // If we already ran the sample, the indexer will remember that it already
            // indexed the sample data and not run again
            // To avoid this, reset the indexer if it exists
            exists = await searchService.Indexers.ExistsAsync(indexer.Name);
            if (exists)
            {
                await searchService.Indexers.ResetAsync(indexer.Name);
            }

            await searchService.Indexers.CreateOrUpdateAsync(indexer);

            // We created the indexer with a schedule, but we also
            // want to run it immediately
            Console.WriteLine("Running Azure SQL indexer...");

            try
            {
                await searchService.Indexers.RunAsync(indexer.Name);
            }
            catch (CloudException e) when (e.Response.StatusCode == (HttpStatusCode)429)
            {
                Console.WriteLine("Failed to run indexer: {0}", e.Response.Content);
            }
        }*/