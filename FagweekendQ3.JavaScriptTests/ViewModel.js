  var setupModel = function (modelData) {
        var viewModel = ko.mapping.fromJS(modelData);

        viewModel.TotalLength = ko.dependentObservable(function () {
            var sum = 0;
            for (var i = 0; i < this.Tracks().length; i++) {
                sum = sum + this.Tracks()[i].TrackLength();
            };
            return (new Date).clearTime()
              .addSeconds(sum)
              .toString('H:mm:ss');
        }, viewModel);

        viewModel.AddTrack = function () {
            viewModel.Tracks.push({ TrackNo: ko.observable(5), Name: ko.observable("test"), TrackLength: ko.observable(213) });
            //push track to server
        };

        ko.applyBindings(viewModel);
		return viewModel;
    };
