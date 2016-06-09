angular.module("Home")
    .factory("playersService",
        function ($http, baseService) {
            console.log("PlayersService initialized");

            var playersAPI = {};

            playersAPI.Player = function (playerinfo) {
                return baseService.post('api/players', playerinfo);
            }

            playersAPI.getPlayers = function () {
                return baseService.get('api/players');
            }

            return playersAPI;
        });