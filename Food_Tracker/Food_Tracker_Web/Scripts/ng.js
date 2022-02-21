var app = angular.module("foodTracker", []);

app.controller("accountCntrl", function ($scope,$http) {

    $scope.GetUser = function () {
        $scope.loading = true;

        $http({
            method: "POST",
            url: apiUrl("../User/GetUser"),
            dataType: 'json',
            data: { Text: $('#searchText').val() }
        }).then(function mySuccess(response) {
            if (response.data.Success) {
                $scope.users = response.data.Users;
            }
            else
                Error($scope, response.data.error);
            $scope.loading = false;
        }, function myError(response) {
            Error($scope, response.data + " " + response.statusText);
            $scope.loading = false;
        });
    }
});