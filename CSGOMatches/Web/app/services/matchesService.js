angular.module("Home")
    .factory("matchesService",
        function ($http, baseService) {
            console.log("MatchesService initialized");

            var matchesAPI = {};

            matchesAPI.addMatch = function (matchinfo) {
                return baseService.post('api/matches', matchinfo);
            }

            matchesAPI.vote = function (voteinfo) {
                return baseService.post('api/votes', voteinfo);
            }

            matchesAPI.getMatches = function () {
                return baseService.get('api/matches');
            }
            
            matchesAPI.getMatch = function (id) {
                return baseService.get('api/matches/' + id);
            }

            matchesAPI.getMaps = function () {
                return baseService.get('api/maps');
            }

            matchesAPI.deleteMatch = function(id) {
                return baseService.delete('api/matches/' + id);
            }

            return matchesAPI;
        });