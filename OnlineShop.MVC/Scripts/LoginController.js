
var app = angular.module("loginModule", ["ngRoute"]);

app.service("loginService", function ($http, $q) {
    var fac = {};
    fac.LoginUser = function (data) {
        var defer = $q.defer();
        $http({
            url: '/Home/Login',
            method: 'POST',
            data: data
        }).then(function successCallback(response) {
            defer.resolve(response);
        }, function errorCallback(response) {
            alert('ERROR!');
            defer.reject(response);
        });
        return defer.promise;
    }
    return fac;
});


app.controller("loginController", function ($scope, loginService) {

    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.UserData = {
        Email: '',
        Password: ''
    };

    //Check to form Validation 
    $scope.$watch('loginForm.$valid', function (newValue) { // form1 is our form name
        $scope.isFormValid = newValue;
    });

    //Login User
    $scope.LoginUser = function (data) {
        $scope.submitted = true;
        $scope.message = '';
        if ($scope.isFormValid) {
            $scope.UserData = data;

            loginService.LoginUser($scope.UserData).then(function (d) {
                //alert(d);
                if (d == 'Success') {
                    // clear form
                }
            });
        }
        else {
            $scope.message = 'Please fill the required fields value';
        }
    }
})

