var apiApp = window.apiApp;

//apiApp.directive('focusOn', function () {
//    return function (scope, elem, attr) {
//        scope.$on('focusOn', function (e, name) {
//            if (name === attr.focusOn) {
//                elem[0].focus();
//            }
//        });
//    };
//});

//apiApp.factory('focus', function ($rootScope, $timeout) {
//    return function (name) {
//        $timeout(function () {
//            $rootScope.$broadcast('focusOn', name);
//        });
//    }
//});

apiApp.controller('registrationViewModel', function ($rootScope, $scope, $http, $location) {

    //Properties
    $scope.pageHeading = '';
    $scope.alert = { type: 'danger', msg: '' };
    $scope.apiDocumentationModel = { Name: '', Url:'', Description: '', SampleImplementation:''};

    //methods
    $scope.processData = processData;
    $scope.resetError = clearMsg;

    initVM();

    function initVM() {
        if ($location.absUrl().indexOf('register') >= 0) {
            $scope.pageHeading = "Register your api and let the world know about it. :D";
        }

        if ($location.absUrl().indexOf('update') >= 0) {
            $scope.pageHeading = "Update your api here";
        }
    }

    function processData() {
        if (!validateModel())
        {
            return;
        }
        alert('Post data here');
    }

    function validateModel() {
        if ($scope.apiDocumentationModel.Name == '')
        {
            $scope.alert = { type: 'danger', msg: 'Please enter your API name.' };
            //focus('Name');
            return false;
        }

        if ($scope.apiDocumentationModel.Url == '') {
            $scope.alert = { type: 'danger', msg: 'Please enter your API url.' };
            //focus('Url');
            return false;
        }

        if ($scope.apiDocumentationModel.Description == '') {
            $scope.alert = { type: 'danger', msg: 'Please enter your API Description.' };
            //focus('Description');
            return false;
        }

        if ($scope.apiDocumentationModel.SampleImplementation == '') {
            $scope.alert = { type: 'danger', msg: 'Please enter your API sample implementation to guide your consumer.' };
            //focus('SampleImplementation');
            return false;
        }

        return true;
    }

    function clearMsg()
    {
        $scope.alert = { type:'danger', msg:'' };
    }

});