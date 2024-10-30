window.onload = function () {
	if (true) { // Masaüstü için kontrol
		document.getElementById('popup').style.display = 'flex';
		console.log("PopUp Log")
	}
};

// Kapatma butonuna týklanýnca popup'ý kapat
document.getElementById('closePopup').addEventListener('click', function () {
	closePopup();
});

// Ekranýn herhangi bir yerine týklanýnca popup'ý kapat
window.addEventListener('click', function (event) {
	const popup = document.getElementById('popup');
	if (event.target === popup) {
		closePopup();
	}
});

// Popup'ý kapatan fonksiyon
function closePopup() {
	document.getElementById('popup').style.display = 'none';
}
