$(document).ready(function() {
	$('#fileupload').fileupload({
		dataType: 'json',
		done: function (e, data) {
			$("#Image").val(data.result.image);
			$("#upload-image").attr("src", data.result.image);
		},
		progressall: function (e, data) {
			var progress = parseInt(data.loaded / data.total * 100, 10);
			$('#progress .progress-bar').css('width', progress + '%');
		},
		autoUpload: true,
		acceptFileTypes: "/(\.|\/)(jpe?g|png)$/i",
		started: function () {
			$("#progress").show();
		},
		always: function () {
			$('#progress .progress-bar').css('width', '0');
			$("#progress").hide();
		}
	});

	$("#deleteImage").click(function () {
		$("#upload-image").attr("src", null);
		$("#Image").val(null);
	});
});

