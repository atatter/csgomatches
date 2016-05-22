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

            return teamsAPI;
        });