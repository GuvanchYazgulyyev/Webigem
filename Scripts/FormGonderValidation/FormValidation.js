document.addEventListener("DOMContentLoaded", function () {
    document.querySelector("form").addEventListener("submit", function (event) {
        let isValid = true;

        // Ad Soyad Kontrolü
        let adSoyad = document.getElementById("AdSoyad");
        if (adSoyad.value.trim() === "") {
            showError(adSoyad, "Ad Soyad zorunludur!");
            isValid = false;
        } else {
            clearError(adSoyad);
        }

        // E-Posta Kontrolü
        let email = document.getElementById("EPosta");
        let emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        if (!emailPattern.test(email.value.trim())) {
            showError(email, "Geçerli bir e-posta adresi giriniz!");
            isValid = false;
        } else {
            clearError(email);
        }

        // Telefon Kontrolü (Sadece rakam ve 10-11 karakter)
        let telNo = document.getElementById("TelNo");
        let telPattern = /^[0-9]{10,11}$/;
        if (!telPattern.test(telNo.value.trim())) {
            showError(telNo, "Telefon numarası 10 veya 11 rakam olmalıdır!");
            isValid = false;
        } else {
            clearError(telNo);
        }

        // Proje Başlığı Kontrolü
        let projeBaslik = document.getElementById("ProjeBaslik");
        if (projeBaslik.value.trim() === "") {
            showError(projeBaslik, "Proje başlığı zorunludur!");
            isValid = false;
        } else {
            clearError(projeBaslik);
        }

        // Mesaj Kontrolü
        let mesaj = document.getElementById("ileti");
        if (mesaj.value.trim() === "") {
            showError(mesaj, "Mesaj alanı boş bırakılamaz!");
            isValid = false;
        } else {
            clearError(mesaj);
        }

        // Eğer hata varsa form gönderimini durdur
        if (!isValid) {
            event.preventDefault();
        }
    });

    // Hata mesajı gösterme fonksiyonu
    function showError(input, message) {
        let parent = input.parentElement;
        let errorSpan = parent.querySelector(".error-message");

        if (!errorSpan) {
            errorSpan = document.createElement("span");
            errorSpan.className = "error-message text-danger";
            parent.appendChild(errorSpan);
        }

        errorSpan.innerText = message;
        input.classList.add("is-invalid");
    }

    // Hata mesajını temizleme fonksiyonu
    function clearError(input) {
        let parent = input.parentElement;
        let errorSpan = parent.querySelector(".error-message");

        if (errorSpan) {
            parent.removeChild(errorSpan);
        }

        input.classList.remove("is-invalid");
    }
});