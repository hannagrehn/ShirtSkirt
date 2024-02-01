

using ShirtSkirt.Entities;
using ShirtSkirt.Repositories;
using System.Diagnostics;

namespace ShirtSkirt.Services;

public class ReviewService
{
    private readonly ReviewRepo _reviewRepo;
    //private readonly ReviewService _reviewService;

    public ReviewService(ReviewRepo reviewRepo)
    {
        _reviewRepo = reviewRepo;
    }

    public ReviewEntity CreateReview(string reviewerName, int rating, string reviewText, DateOnly reviewDate)
    {
        

        try
        {
            var reviewEntity = _reviewRepo.GetOne(x =>
                x.ReviewText == reviewText);

            reviewEntity ??= _reviewRepo.Create(new ReviewEntity
            {
                ReviewerName = reviewerName,
                Rating = rating,
                ReviewText = reviewText,
                ReviewDate = reviewDate

            });
            return reviewEntity;
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); throw; }     
    }

    public ReviewEntity GetReviewByReviewerName(string reviewerName)
    {
        var reviewEntity = _reviewRepo.GetOne(x => x.ReviewerName == reviewerName);
        return reviewEntity;
    }

    public ReviewEntity GetReviewById(int id)
    {
        var reviewEntity = _reviewRepo.GetOne(x => x.ReviewId == id);
        return reviewEntity;
    }

    public IEnumerable<ReviewEntity> GetReviews()
    {
        var reviews = _reviewRepo.GetAll();
        return reviews;
    }

    public ReviewEntity UpdateReview(ReviewEntity reviewEntity)
    {
        var updatedReviewEntity = _reviewRepo.Update(x => x.ReviewId == reviewEntity.ReviewId, reviewEntity);
        return updatedReviewEntity;
    }

    public bool DeleteReview(int id)
    {
        try
        {
            return _reviewRepo.Delete(x => x.ReviewId == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
            return false;
        }
    }

}
