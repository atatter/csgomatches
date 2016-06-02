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

            matchesAPI.vote = function(voteinfo) {
                return $http({
                    method: 'POST',
                    url: 'http://localhost:10742/api/votes',
                    data: voteinfo
                });
            }

            matchesAPI.getMatches = function() {
                return $http({
                    method: 'GET',
                    url: 'http://localhost:10742/api/matches'
            });
            }
            
            matchesAPI.getMatch = function(id) {
                return $http({
                    method: 'GET',
                    url: 'http://localhost:10742/api/matches/' + id
                });
            }

            matchesAPI.getMaps = function () {
                return $http({
                    method: 'GET',
                    url: 'http://localhost:10742/api/maps'
                });
            }

            return matchesAPI;
        });