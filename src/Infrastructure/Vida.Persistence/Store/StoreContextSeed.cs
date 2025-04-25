using System.Text.Json;
using Vida.Domain.Entities.News;
using Vida.Domain.SpaceEntities;

namespace Vida.Persistence.Store;
public class StoreContextSeed
{
	public static async Task SeedProductDataAsync(StoreContext storeContext)
	{
		if (!storeContext.Availabilities.Any())
		{
			const string AvailabilityFilePath = "/Vida/src/Infrastructure/Vida.Persistence/Store/DataSeeding/availability.json";

			var AvailabilityData = await File.ReadAllTextAsync(AvailabilityFilePath);

			var Availabilities = JsonSerializer.Deserialize<List<Availability>>(AvailabilityData);

			if (Availabilities?.Count > 0)
			{
				foreach (var availability in Availabilities)
				{
					storeContext.Availabilities.Add(availability);
				}
			}
		}

		if (!storeContext.Spaces.Any())
		{
			const string spaceFilePath = "/Vida/src/Infrastructure/Vida.Persistence/Store/DataSeeding/space.json";

			var spaceData = await File.ReadAllTextAsync(spaceFilePath);

			var spaces = JsonSerializer.Deserialize<List<Space>>(spaceData);

			if (spaces?.Count > 0)
			{
				foreach (var space in spaces)
				{
					storeContext.Spaces.Add(space);
				}
			}
		}

		if (!storeContext.Courses.Any())
		{
			const string CourseFilePath = "/Vida/src/Infrastructure/Vida.Persistence/Store/DataSeeding/course.json";

			var CourseData = await File.ReadAllTextAsync(CourseFilePath);

			var Courses = JsonSerializer.Deserialize<List<Course>>(CourseData);

			if (Courses?.Count > 0)
			{
				foreach (var course in Courses)
				{
					storeContext.Courses.Add(course);
				}
			}
		}

        if (!storeContext.News.Any())
        {
            const string NewsFilePath = "/Vida/src/Infrastructure/Vida.Persistence/Store/DataSeeding/news.json";

            var NewsData = await File.ReadAllTextAsync(NewsFilePath);

            var NewsList = JsonSerializer.Deserialize<List<News>>(NewsData);

            if (NewsList?.Count > 0)
            {
                foreach (var news in NewsList)
                {
                    storeContext.News.Add(news);
                }
            }
        }

        await storeContext.SaveChangesAsync();
	}
}