using Backend.Profiles.Domain.Model.Commands.ReviewCommands;
using Backend.Profiles.Domain.Model.Queries.ReviewQueries;
using Backend.Profiles.Domain.Services;
using Backend.Profiles.Interfaces.REST.Resources;
using Backend.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ReviewController(IReviewCommandService reviewCommandService,IReviewQueryService reviewQueryService): ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> CreateReview(CreateReviewResource resource)
    {
        var createReviewCommand = CreateReviewCommandFromResourceAssembler.ToCommandFromResource(resource);
        var review = await reviewCommandService.Handle(createReviewCommand);
        if (review is null) return BadRequest();
        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return CreatedAtAction(nameof(GetReviewById), new { reviewId = reviewResource.Id }, reviewResource);
    }
    
    [HttpDelete("{reviewId:int}")]
    public async Task<IActionResult> DeleteReview(int reviewId)
    {
        var deleteReviewCommand = new DeleteReviewCommand(reviewId);
        var review = await reviewCommandService.Handle(deleteReviewCommand);
        if (review is null) return NotFound();
        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(reviewResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllReviews()
    {
        var getAllReviewsQuery = new GetAllReviewsQuery();
        var reviews = await reviewQueryService.Handle(getAllReviewsQuery);
        var reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reviewResources);
    }
    
    [HttpGet("{reviewId:int}")]
    public async Task<IActionResult> GetReviewById(int reviewId)
    {
        var getReviewByIdQuery = new GetReviewByIdQuery(reviewId);
        var review = await reviewQueryService.Handle(getReviewByIdQuery);
        if (review == null) return NotFound();
        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(reviewResource);
    }
    
    
    
}