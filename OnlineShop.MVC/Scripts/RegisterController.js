
var app = angular.module("registerModule", ["ngRoute"]);

app.service("registerService", function ($http, $q) {
    var fac = {};
    fac.RegisterUser = function (data) {
        var defer = $q.defer();
        $http({
            url: '/Home/Register',
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


app.controller("registerController", function ($scope, registerService) {

    $scope.submitted = false;
    $scope.message = '';
    $scope.isFormValid = false;
    $scope.UserData = {
        Email: '',
        Password: '',
        ConfirmPassword: ''
    };

    //Check to form Validation 
    $scope.$watch('registerForm.$valid', function (newValue) { // form1 is our form name
        $scope.isFormValid = newValue;
    });

    //Register User
    $scope.RegisterUser = function (data) {
        $scope.submitted = true;
        $scope.message = '';
        if ($scope.isFormValid) {
            $scope.UserData = data;

            registerService.RegisterUser($scope.UserData).then(function (d) {
                //alert(d);
                if (d == 'Success') {
                    // cler form
                }
            });
        }
        else {
            $scope.message = 'Please fill the required fields value';
        }
    }
})

