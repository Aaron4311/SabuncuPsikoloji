window.onload = function () {
	if (window.innerWidth > 768) { // Masa�st� i�in kontrol
		document.getElementById('popup').style.display = 'block';
		console.log("PopUp Log")
	}
};

// Kapatma butonuna t�klan�nca popup'� kapat
document.getElementById('closePopup').addEventListener('click', function () {
	closePopup();
});

// Ekran�n herhangi bir yerine t�klan�nca popup'� kapat
window.addEventListener('click', function (event) {
	const popup = document.getElementById('popup');
	if (event.target === popup) {
		closePopup();
	}
});

// Popup'� kapatan fonksiyon
function closePopup() {
	document.getElementById('popup').style.display = 'none';
}
