angular.module("Home")
    .factory("playersService",
        function ($http, baseService) {
            console.log("PlayersService initialized");

            var playersAPI = {};

            playersAPI.addPlayer = function (playerinfo) {
                return baseService.post('api/players', playerinfo);
            }

            playersAPI.deletePlayer = function(id) {
                return baseService.delete('api/players/' + id);
            }

            playersAPI.editPlayer = function(id, playerinfo) {
                return baseService.put('api/players/' + id, playerinfo);
            }

            playersAPI.getPlayers = function () {
                return baseService.get('api/players');
            }

            return playersAPI;
        });