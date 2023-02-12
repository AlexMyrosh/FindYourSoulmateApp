using BLL.Enums;
using DAL.Enums;

namespace BLL.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string TelegramUsername { get; set; }

        public string Email { get; set; }

        public int? UniversityYear { get; set; }

        public GenderModel? Gender { get; set; }

        public LookingForGenderModel? LookingForGender { get; set; }

        public RelationTypeModel? LookingForRelationType { get; set; }

        public UniversityFacultyModel? UniversityFaculty { get; set; }

        public string? City { get; set; }

        public bool IsDeleted { get; set; }

        public List<UserAnswerModel> Answers { get; set; }
    }
}
