var searchAppModule = window.searchApp;

searchAppModule.service('apiModel', function ($http) {

    this.getApi = function (id, callback) {
        $http.get('/scrum-template/api/documentation/single/' + id).success(function (data) {
            if (callback != undefined) {
                callback(data);
            }
        });
    }

    this.getLatestApi = function (count, callback) {
        console.log(count);
        $http.get('/scrum-template/api/documentation/latest/' + count).success(function (data) {
            if (callback != undefined) {
                callback(data);
            }
        });
    }


    this.searchApi = function (keyword, callback) {
        $http.get('/scrum-template/api/documentation/search/' + keyword).success(function (data) {
            if (callback != undefined) {
                callback(data);
            }
        });
    }

    //this.getApiList = function (callback) {
    //    $http.get('/scrum-template/api/documentation/').success(function (data) {
    //        if (callback != undefined) {
    //            callback(data);
    //        }
    //    });
    //}

});