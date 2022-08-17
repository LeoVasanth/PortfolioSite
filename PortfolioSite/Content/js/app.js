

var MyApp = angular.module("MyApp", []);
MyApp.controller("MyCntrl", function ($scope, $http, $window) {
    $scope.UserDetails = {};

    $scope.Login = function () {

        
        $scope.UserDetails.username = $scope.Usr;
        $scope.UserDetails.pwd = $scope.Pwd;

        
        $http({
            method: "post",
            url: "Login/Login",
            datatype: "json",
            data: JSON.stringify($scope.UserDetails)
        }).then(function (response) {
            $scope.Usr = "";
            $scope.Pwd = "";
            if (response.XMLHttpRequest == XMLHttpRequest.ok) {
                $window.location = "/Admin/Index";
            }
            },
            function (response) {
                alert("Error occured"); $scope.Usr = "";
                $scope.Pwd = "";
            });
    };

    $scope.msg = {};

    $scope.InsertMsg = function () {

        $scope.msg.Name = $scope.Name;
        $scope.msg.Email = $scope.Email;
        $scope.msg.Message = $scope.Message;

        $http({
            method: "post",
            url: "Home/InsertMsg",
            datatype: "json",
            data: JSON.stringify($scope.msg)
        }).then(function (response) {
            $scope.Name = "";
            $scope.Email = "";
            $scope.Message = "";
            alert(response.data);

        },
            function (response) {
                alert("Error occured"); $scope.msg.Name = "";
                $scope.msg.Email = "";
                $scope.msg.Message = "";
            });

    };
    $scope.MessagesList = {}
    $scope.GetMessages = function () {
        

        $http({
            method: "get",
            url: "/Admin/GetMessages"
        }).then(function (response) {
            $scope.MessagesList = response.data;
            
        }, function () {
                
                alert("Error Occured");
        });

    };

    $scope.DeleteMessage = function (msgs) {

        $http({
            method: "post",
            url: "/Admin/DeleteMessage",
            datatype: "json",
            data: JSON.stringify(msgs)
        }).then(function (response) {
            
            $window.location = "/Admin/Index";
            if (response.XMLHttpRequest == XMLHttpRequest.ok) {
                alert("Message Deleted");
                $scope.GetMessages;
            }
            

        }, function () {

            alert("Error Occured");
        });

    };
});

