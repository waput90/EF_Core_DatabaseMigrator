
// Sample migration method that can run seperately
[HttpGet, Route("run")]
public async Task<IActionResult> RunMigration()
{
    // we must need to create service locator pattern to get our current dbcontext
    var context = ServiceLocatorHelper.Current.GetInstance<YOURDBCONTEXT>();
    
    // set connection string for your db context to instruct the migrator
    // to used this database connection
    context.Database.SetConnectionString("YOUR CONNECTION STRING HERE");
    
    // will programmatically run `dotnet ef database update -c YOURDBCONTEXT`
    await context.Database.MigrateAsync();

    // return the result that migration successfully run.
    return Ok(new { success = true, msg = "Migration run successfully" });
}
