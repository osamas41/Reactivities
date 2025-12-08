using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Persistence;

namespace API.Controllers;

public class ActivitiesController(AppDBContext context): BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetACtivities()
    {
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        var activity = await context.Activities.FindAsync(id);

        if(activity == null) return NotFound();

        return activity;
    }
}
