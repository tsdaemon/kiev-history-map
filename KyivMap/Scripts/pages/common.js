$(document).ready(function() {
	$("input.numeric").numeric();
});

function deleteRow(data) {
	if (data.result == "success") {
		var tr = $("tr[data-id='" + data.id + "']");
		tr.addClass("danger");
		tr.fadeOut();
	} else {
		alert("Fail on delete");
	}
}

String.prototype.translit = (function () {
	var L = {
		'А': 'A', 'а': 'a', 'Б': 'B', 'б': 'b', 'В': 'V', 'в': 'v', 'Г': 'G', 'г': 'g',
		'Д': 'D', 'д': 'd', 'Е': 'E', 'е': 'e', 'Ё': 'Yo', 'ё': 'yo', 'Ж': 'Zh', 'ж': 'zh',
		'З': 'Z', 'з': 'z', 'И': 'I', 'и': 'i', 'Й': 'Y', 'й': 'y', 'К': 'K', 'к': 'k',
		'Л': 'L', 'л': 'l', 'М': 'M', 'м': 'm', 'Н': 'N', 'н': 'n', 'О': 'O', 'о': 'o',
		'П': 'P', 'п': 'p', 'Р': 'R', 'р': 'r', 'С': 'S', 'с': 's', 'Т': 'T', 'т': 't',
		'У': 'U', 'у': 'u', 'Ф': 'F', 'ф': 'f', 'Х': 'Kh', 'х': 'kh', 'Ц': 'Ts', 'ц': 'ts',
		'Ч': 'Ch', 'ч': 'ch', 'Ш': 'Sh', 'ш': 'sh', 'Щ': 'Sch', 'щ': 'sch', 'Ъ': '', 'ъ': '',
		'Ы': 'Y', 'ы': 'y', 'Ь': "", 'ь': "", 'Э': 'E', 'э': 'e', 'Ю': 'Yu', 'ю': 'yu',
		'Я': 'Ya', 'я': 'ya'
	},
			r = '',
			k;
	for (k in L) r += k;
	r = new RegExp('[' + r + ']', 'g');
	k = function (a) {
		return a in L ? L[a] : '';
	};
	return function () {
		return this.replace(r, k);
	};
})();

function toTitleCase(str) {
	return str.replace(/\w\S*/g, function(txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });
}