using Models;
using TrainerInfo=TrainerEntity.Entities;
namespace BusinessLogic
{
    public class Mapper
    {
        // entity to model
        public UserTable MapUserTable(TrainerInfo.UserTable usertable)
        {
            return new UserTable()
            {
                Id = usertable.UserId,
                Email = usertable.EmailId,
                Name = usertable.Name,
                Password = usertable.Password,
            };
        }
        public Details MapDetail(TrainerInfo.Detail detail)
        {
            return new Details()
            {
                UserID = detail.UserId,
                FullName = detail.FullName,
                Gender = detail.Gender,
                Address = detail.Address,
                AboutMe = detail.AboutMe,
                PhoneNo = detail.PhoneNo,
                Email = detail.EmailId,
                Website = detail.Website,
            };
        }
        public Skills MapSkill(TrainerInfo.Skill skill)
        {
            return new Skills()
            {
                USERID = skill.UserId,
                SKILL_1 = skill.Skill1,
                SKILL_2 = skill.Skill2,
                SKILL_3 = skill.Skill3,
            };
        }
        public Experience MapExperience(TrainerInfo.Experience experience)
        {
            return new Experience()
            {
                USERID = experience.UserId,
                COMPANY1 = experience.Company1,
                COMPANY2 = experience.Company2,
                COMPANY3 = experience.Company3,
            };
        }
        public Education MapEducation(TrainerInfo.Education education)
        {
            return new Education()
            {
                REGISTER_NO = education.RegisterNo,
                USERID = education.UserId,
                COLLEGE_NAME = education.CollegeName,
                STREAM = education.Stream,
                BRANCH = education.Branch,
                PERCENTAGE = (double)education.Percentage,
                START_YEAR = (int)education.StartYear,
                END_YEAR = (int)education.EndYear,
            };
        }

        // model to entity
        public TrainerInfo.UserTable mapusertable(UserTable usertable)
        { 
            return new TrainerInfo.UserTable()
            {
                UserId = usertable.Id,
                EmailId = usertable.Email,
                Name = usertable.Name,
                Password = usertable.Password,

            };
        }
        public TrainerInfo.Detail mapdetail(Details detail)
        {
            return new TrainerInfo.Detail()
            {
                UserId = detail.UserID,
                FullName = detail.FullName,
                Gender = detail.Gender,
                Address = detail.Address,
                AboutMe = detail.AboutMe,
                PhoneNo = detail.PhoneNo,
                EmailId = detail.Email,
                Website = detail.Website,
            };
        }
        public TrainerInfo.Skill mapskill(Skills skill)
        {
            return new TrainerInfo.Skill()
            {
                UserId = skill.USERID,
                Skill1 = skill.SKILL_1,
                Skill2 = skill.SKILL_2,
                Skill3 = skill.SKILL_3,
            };
        }
        public TrainerInfo.Experience mapexperience(Experience experience)
        {
            return new TrainerInfo.Experience()
            {
                UserId = experience.USERID,
                Company1 = experience.COMPANY1,
                Company2 = experience.COMPANY2,
                Company3 = experience.COMPANY3,
            };
        }
        public TrainerInfo.Education mapeducation(Education education)
        {
            return new TrainerInfo.Education()
            {
                RegisterNo = education.REGISTER_NO,
                UserId = education.USERID,
                CollegeName = education.COLLEGE_NAME,
                Stream = education.STREAM,
                Branch = education.BRANCH,
                Percentage = (double)education.PERCENTAGE,
                StartYear = (int)education.START_YEAR,
                EndYear = (int)education.END_YEAR,
            };
        }
    }
}