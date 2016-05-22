angular.module("Home")
    .factory("matchesService",
        function ($http) {
            console.log("MatchesService initialized");

            var matchesAPI = {};

            matchesAPI.addMatch = function(matchinfo) {
                return $http({
                    method: 'POST',
                    url: 'http://localhost:10742/api/matches',
                    data: matchinfo
                });
            }

            matchesAPI.getMatches = function() {
                return $http({
                    method: 'GET',
                    url: 'http://localhost:10742/api/matches'
            });
            }

            return matchesAPI;
        });