document.querySelectorAll('.toggle-password').forEach(button => {
    button.addEventListener('click', () => {
        const input = document.getElementById(button.dataset.target);
        const isPassword = input.type === 'password';
        input.type = isPassword ? 'text' : 'password';
        button.textContent = isPassword ? '•' : '♦';
        button.setAttribute('aria-label', isPassword ? 'Скрыть пароль' : 'Показать пароль');
    });
});

const pinInput = document.getElementById('pin');
if (pinInput !== null) {
    pinInput.addEventListener('input', () => {
        pinInput.value = pinInput.value.replace(/\D/g, '').slice(0, 4);
    });
}

const ErrorMessage = document.getElementById("error");
const Form = document.getElementById("form");

Form.addEventListener("submit", (event) => {
    try {
        ErrorMessage.textContent = "";

        const firstName = document.getElementById("firstName")?.value.trim();
        const lastName = document.getElementById("lastName")?.value.trim();
        const patronymic = document.getElementById("patronymic")?.value.trim();
        const login = document.getElementById("login")?.value.trim();
        const phoneOrEmail = document.getElementById("phoneOrEmail")?.value.trim();
        const loginOrEmailOrPhone = document.getElementById("loginOrEmailOrPhone")?.value.trim();
        const password = document.getElementById("password")?.value.trim();
        const passwordRepeat = document.getElementById("passwordRepeat")?.value.trim();
        const pincode = document.getElementById('pin')?.value.trim();

        if (firstName !== undefined || lastName !== undefined || patronymic !== undefined) {
            
            const firstname = /^[А-Яа-яЁё-]{2,}$/;
            const lastname = /^[А-Яа-яЁё-]{2,}$/;
            const Patronymic = /^[А-Яа-яЁё-]{2,}$/;

            const fnametest = firstname.test(firstName)
            const lnametest = lastname.test(lastName)
            const patrtest = Patronymic.test(patronymic)

            if (!fnametest) {
                throw new Error("Имя пишется только русскими буквами!");
            }

            if (!lnametest) {
                throw new Error("Фамилия пишется только русскими буквами!");
            }

            if (!patrtest) {
                throw new Error("Отчество пишется только русскими буквами!");
            }
        }

        if (login !== undefined) {
            if (login.length < 3) {
                throw new Error("Логин должен быть не меньше, чем 3 символа!");
            }
        }

        if (phoneOrEmail !== undefined) {
            
            const email = /^[^\s@]+@[^\s@]+.[^\s@]{2,}$/;
            const phone = /^(8|\+7)\d{10}$/;

            const emailtest = email.test(phoneOrEmail);
            const phonetest = phone.test(phoneOrEmail);
            
            if (!emailtest && !phonetest) {
                throw new Error("Напишите почту с символом @ или номер телефона, который начинается с 8 или +7!");
            }
        }

        if (loginOrEmailOrPhone !== undefined) {
            
            const email = /^[^\s@]+@[^\s@]+.[^\s@]{2,}$/;
            const phone = /^(8|\+7)\d{10}$/;
            const login = /^(?!\d+$)[^\s@]{4,}$/;

            const emailtest = email.test(loginOrEmailOrPhone);
            const phonetest = phone.test(loginOrEmailOrPhone);
            const logintest = login.test(loginOrEmailOrPhone);
            
            if (!emailtest && !phonetest && !logintest) {
                throw new Error("Напишите почту с символом @ или номер телефона, который начинается с 8 - +7 или логин, который больше, чем 3 символа!");
            }
        }

        if (password !== undefined) {
            if (password.length < 6) {
                throw new Error("Пароль должен быть не меньше 6 символов!");
            }
        }

        if (passwordRepeat !== undefined) {
            if (password !== passwordRepeat) {
                throw new Error("Пароли не совпадают!");
            }
        }

        if (pincode !== undefined) {
            if (pincode.length < 4) {
                throw new Error("Пинкод должен быть 4 символа!");
            }
        }

    } 
    catch (Error) {
        event.preventDefault();
        ErrorMessage.textContent = `Ошибка: ${Error.message}`;
    }
});