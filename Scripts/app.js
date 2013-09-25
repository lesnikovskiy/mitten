function Hip(name, pass, location) {
	this.name = ko.observable(name);
	this.password = ko.observable(pass);
	this.location = ko.observable(location);
}

function HipViewModel() {
	var self = this;

	self.hips = ko.observable([]);
	self.addHip = function() {
		navigator.geolocation.getCurrentPosition(function(pos) {
			var hip = new Hip($('#name').val(), $('#pass').val(), {
				lat: pos.coords.lat,
				lng: pos.coords.lng
			});
			console.log(ko.toJSON(hip));
			console.log(ko.toJS(hip));
			$.ajax({
				url: '/api/hip',
				cache: false,
				type: 'POST',
				dataType: 'json',
				contentType: 'application/json',
				data: ko.toJSON(hip),
				success: function (data) {
					console.log(data);
				}
			});
		});
	};
}

$(document).ready(function () {
	ko.applyBindings(new HipViewModel());
	//$('#btnRegisterUser').click(function () {
	//	navigator.geolocation.getCurrentPosition(function (pos) {
	//		if (pos) {
	//			$.ajax({
	//				url: '/api/hip',
	//				cache: false,
	//				type: 'POST',
	//				dataType: 'json',
	//				contentType: 'application/json',
	//				data: "{Name:" + $('#name').val() + ", Password: " + $('#pass').val() + ",Location: {Lat: " + pos.coords.lat + ",Lng:" + pos.coords.lng + "}}",
	//				success: function (data) {
	//					console.log(data);
	//				}
	//			});
	//		} else {
	//			console.log('geolocation not found');
	//		}
	//	});

	//	return false;
	//});
});