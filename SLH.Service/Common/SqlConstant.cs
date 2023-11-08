using System;
using System.Collections.Generic;
using System.Text;

namespace SLH.Service.Common
{
    public class SqlConstant
    {
        #region User
        public const string GetUserByUserId = "GetUserByUserId";
        public const string SignUp = "UserSignUp";
        public const string SignIn = "UserSignIn";
        public const string UpdateProfile = "UpdateProfile";
        public const string UserStatusChange = "UserStatusChange";
        public const string UserDetailsById = "UserDetailsById";
        public const string GetRolesForRegister = "GetRolesForRegister";
        public const string GetSportsForRegister = "GetSportsForRegister";
        public const string RoleWiseUsers = "RoleWiseUsers";
        public const string GetPlayersForTeam = "GetPlayersForTeam";
        public const string GetTeamPlayer = "GetTeamPlayer";

        //public const string ChangePassword = "ChangePassword";
        //public const string ForgotPassword = "CheckUserAvailableWithEmail";
        //public const string AdminForgotPassword = "CheckAdminUserAvailable";
        //public const string AllUsers = "AllUsers";
        #endregion

        #region Sports
        public const string GetAllSports = "GetAllSports";
        public const string SportAdd = "SportAdd";
        public const string SportUpdate = "SportUpdate";
        public const string SportDelete = "SportDelete";
        #endregion

        #region Venues
        public const string GetAllVenues = "GetAllVenues";
        public const string VenueAdd = "VenueAdd";
        public const string VenueUpdate = "VenueUpdate";
        public const string VenueDelete = "VenueDelete";
        #endregion

        #region Teams
        public const string GetAllTeams = "GetAllTeams";
        public const string TeamAdd = "TeamAdd";
        public const string TeamUpdate = "TeamUpdate";
        public const string TeamDelete = "TeamDelete";
        public const string TeamPlayerAdd = "TeamPlayerAdd";
        public const string TeamPlayerRelease = "TeamPlayerRelease";
        #endregion

        #region Tournaments
        public const string GetAllTournaments = "GetAllTournaments";
        public const string TournamentAdd = "TournamentAdd";
        public const string TournamentUpdate = "TournamentUpdate";
        public const string TournamentDelete = "TournamentDelete";
        public const string TournamentTeamAdd = "TournamentTeamAdd";
        public const string TournamentTeamRelease = "TournamentTeamRelease";
        #endregion

        #region Matches
        public const string GetAllMatches = "GetAllMatches";
        public const string MatchAdd = "MatchAdd";
        public const string MatchUpdate = "MatchUpdate";
        public const string MatchDelete = "MatchDelete";
        #endregion
    }
}
