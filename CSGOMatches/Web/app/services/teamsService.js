angular.module("Home")
    .factory("teamsService",
        function ($http, baseService) {

            var teamsAPI = {};

            teamsAPI.addTeam = function (teaminfo) {
                console.log("Team info in Team Service: " + teaminfo);
                return baseService.post('api/teams', teaminfo);
            }

            teamsAPI.getTeams = function () {
                return baseService.get('api/teams');
            }

            teamsAPI.deleteTeam = function (id) {
                console.log("Attempting to delete team: " + id);
                return baseService.delete('api/teams/' + id);
            }

            teamsAPI.editTeam = function (teaminfo, id) {
                return baseService.put('api/teams/' + id, teaminfo);
            }

            teamsAPI.getTeamById = function (id) {
                return baseService.get('api/teams/' + id);
            }

            return teamsAPI;
        });