angular.module("Home")
    .controller("homeController",
        function ($scope, teamsService, usersService ,matchesService, $location) {

            $(".footer").css("display", "block");
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
                Email: "alekstattesr@gmail.com",
                Password: "Kammajaa12#",
                ConfirmPassword: "Kammajaa12#"
            };

            var logininfo = {
                grant_type: 'password',
                username: "alekstatter@gmail.com",
                password: "Kammajaa12#"
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


            //$scope.hasAuth = function () {
            //    var answer = usersService.isAuth();
            //    console.log("hasAuth answer is: " + answer)
            //    return answer;
            //};

            var loadMatches = function() {
                matchesService.getMatches()
                    .success(function(resp) {
                        console.log("Matches loaded");
                        console.log(resp);
                        $scope.matches = resp;
                    });
            };

            loadMatches();

            $scope.voteForTeamOne = function(match) {
                var voteinfo = {
                    MatchId: match.matchId,
                    VoteForTeamOne: true,
                    VoteForTeamTwo: false
                }
                matchesService.vote(voteinfo);
                loadMatches();
            };

            $scope.voteForTeamTwo = function(match) {
                var voteinfo = {
                    MatchId: match.matchId,
                    VoteForTeamOne: false,
                    VoteForTeamTwo: true
                }
                matchesService.vote(voteinfo);
                loadMatches();
            };

            $scope.goToView = function(id) {
                $location.path("/matchview").search({ id: id });
                console.log("id = " + id);
            };

            //usersService.isAuth();

            $scope.auth = false;

            usersService.getUserInfo().then(function successCallback(response) {
                $scope.auth = true;
                console.log($scope.auth);
            });


            console.log($scope.auth);

            loadMatches();


        });