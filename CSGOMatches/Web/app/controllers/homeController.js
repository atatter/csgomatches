angular.module("Home")
    .controller("homeController",
        function ($scope, usersService, teamsService, matchesService) {


            //var teaminfo = {
            //    Name: "NiP"
            //};

            //teamsService.addTeam(teaminfo).success(function(resp) {
            //    console.log("Team added");
            //});

            //var matchinfo = {
            //    TeamOneId: 1,
            //    TeamTwoId: 2
            //}

            //matchesService.addMatch(matchinfo)
            //    .success(function(resp) {
            //        console.log("Match Added");
            //    });

            console.log("HomeController initialized");

            var userinfo = {
                Email: "alekstattes@gmail.com",
                Password: "Kammajaa12#",
                ConfirmPassword: "Kammajaa12#"
            };

            var logininfo = {
                grant_type: 'password',
                username: "alekstatter@gmail.com",
                password: "kammajaa"
            };

            //usersService.registerUser(userinfo)
            //    .then(function(resp) {
            //        console.log("Response message: " + resp);
            //    });

            //usersService.getAuth(logininfo).success(function(resp) {
            //    console.log(resp.userName);
            //    sessionStorage.setItem('accessToken', resp.access_token);
            //});

           
                //usersService.getUserInfo().then(function (resp) {

                //$scope.user = resp.data.email;

                //});

            //$scope.logout = function () {
            //    sessionStorage.removeItem('accessToken');
            //}

            matchesService.getMatches()
                .success(function(resp) {
                    console.log("Matches loaded");
                    console.log(resp);
                    $scope.matches = resp;
                });

        });