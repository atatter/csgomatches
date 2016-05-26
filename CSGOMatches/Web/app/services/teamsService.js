angular.module("Home")
    .factory("teamsService",
        function ($http) {
            console.log("TeamsService initialized");

            var teamsAPI = {};

            teamsAPI.addTeam = function(teaminfo) {
                return $http({
                    method: 'POST',
                    url: 'http://localhost:10742/api/teams',
                    data: teaminfo
                });
            }

            teamsAPI.getTeams = function () {
                return $http({
                    method: 'GET',
                    url: 'http://localhost:10742/api/teams'
                });
            }

            return teamsAPI;
        });