using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory){
            try{
                
                // Enabling preemptive data vailability through Json
                if(!context.NewsCat.Any()){
                    var NewsCatVar = File.ReadAllText("../Infrastructure/Data/newCat.json");
                    // Deserializing a file inot a fittable version
                    var cats = JsonSerializer.Deserialize<List<NewsCat>>(NewsCatVar);

                    // Tracking an addition process
                    foreach(var item in cats){
                        context.NewsCat.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.News.Any()){
					// var NewsVar = File.ReadAllText("../Infrastructure/Data/SeedData/news.json");
                    var NewsVar = File.ReadAllText("../Infrastructure/Data/news.json");
                    // Deserializing a file inot a fittable version
                    var news = JsonSerializer.Deserialize<List<News>>(NewsVar);

                    // Tracking an addition process
                    foreach(var item in news){
                        context.News.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex){
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}