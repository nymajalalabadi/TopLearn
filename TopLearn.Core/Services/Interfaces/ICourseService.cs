using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.Core.DTOs.Course;
using TopLearn.DataLayer.Entities.Course;

namespace TopLearn.Core.Services.Interfaces
{
    public interface ICourseService
    {
        #region Group

        List<CourseGroup> GetAllGroup();

        List<SelectListItem> GetGroupForManageCourse();

        List<SelectListItem> GetSubGroupForManageCourse(int groupId);

        List<SelectListItem> GetTeachers();

        List<SelectListItem> GetLevels();

        List<SelectListItem> GetStatues();

        void AddGroup(CourseGroup group);

        void UpdateGroup(CourseGroup group);
        CourseGroup GetById(int groupId);

        #endregion


        #region Course

        int AddCourse(Course course , IFormFile imgCourse , IFormFile courseDemo);

        List<ShowCourseForAdminViewModel> GetCoursesForAdmin();

        Course GetCourseById(int courseId);

        void UpdateCourse(Course course, IFormFile imgCourse, IFormFile courseDemo);

        Tuple<List<ShowCourseListItemViewModel>, int> GetCourse(int pageId = 1, string filter = ""
           , string getType = "all", string orderByType = "date",
           int startPrice = 0, int endPrice = 0, List<int> selectedGroups = null, int take = 0);

        Course GetCourseForShow(int courseId);

        List<ShowCourseListItemViewModel> GetPopularCourse();

        bool IsFree(int courseId);

        List<Course> GetAllMasterCourses(string userName);

        List<CourseEpisode> GetCourseEpisodesByCourseId(int CourseId);

        bool AddEpisode(AddEpisodeViewModel episodeViewModel, string userName );
        #endregion


        #region Episode

        List<CourseEpisode> GetListEpisodeCorse(int courseId);

        int AddEpisode(CourseEpisode episode, IFormFile episodeFile);

        bool CheckExistFile(string fileName);

        CourseEpisode GetEpisodeById(int episodeId);

        void EditEpisode(CourseEpisode episode, IFormFile episodeFile);
        #endregion


        #region CourseComments

        void AddComment(CourseComment courseComment);

        Tuple<List<CourseComment>, int> GetCourseComment(int courseId , int pageId=1);
        #endregion


        #region Course Vote

        void AddsVote(int userId , int courseId , bool vote);

        Tuple<int, int> GetCourseVotes(int courseId);


        #endregion
    }
}
