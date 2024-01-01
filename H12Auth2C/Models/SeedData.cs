namespace H12Auth2C.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

public static class SeedData
{
    public static async Task Initialize(UserManager<UserDetails> userManager, RoleManager<IdentityRole> roleManager)
    {
        string adminRole = "Admin";
        string travellerRole = "Traveller";
        string adminPassword = "sau";

        if (!await roleManager.RoleExistsAsync(adminRole))
        {
            // Admin rolünü oluştur
            await roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        if (!await roleManager.RoleExistsAsync(travellerRole))
        {
            // Traveller rolünü oluştur
            await roleManager.CreateAsync(new IdentityRole(travellerRole));
        }

        var admins = new[]
        {
        new { Email = "B211210306@sakarya.edu.tr", Name = "Eray", Surname = "POLAT", Gender = true, Birthdate = new DateTime(2000, 9, 12) },
        new { Email = "B211210010@sakarya.edu.tr", Name = "Kürşat", Surname = "SONKUR", Gender = true, Birthdate = new DateTime(2002, 12, 16) }
    };

        foreach (var adminInfo in admins)
        {
            var adminEmail = adminInfo.Email;

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new UserDetails
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    UserAd = adminInfo.Name,
                    UserSoyad = adminInfo.Surname,
                    Gender = adminInfo.Gender,
                    birthdate = adminInfo.Birthdate
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                }
            }
        }
    }


}

