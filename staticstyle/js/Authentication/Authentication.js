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
pinInput.addEventListener('input', () => {
    pinInput.value = pinInput.value.replace(/\D/g, '').slice(0, 4);
});

const ErrorMessage = document.getElementById("error");
const Form = document.getElementById("form");

Form.addEventListener("submit", (event) => {
    try {
        ErrorMessage.textContent = "";

        const firstName = document.getElementById("firstName").value.trim();
        const lastName = document.getElementById("lastName").value.trim();
        const patronymic = document.getElementById("patronymic").value.trim();
        const login = document.getElementById("login").value.trim();
        const phoneOrEmail = document.getElementById("phoneOrEmail").value.trim();
        const loginOrEmailOrPhone = document.getElementById("loginOrEmailOrPhone").value.trim();
        const password = document.getElementById("password").value.trim();
        const passwordRepeat = document.getElementById("passwordRepeat").value.trim();

        if (    
            (document.getElementById("firstName") && !firstName) ||
            (document.getElementById("lastName") && !lastName) ||
            (document.getElementById("patronymic") && !patronymic) ||
            !login ||
            (document.getElementById("phoneOrEmail") && !phoneOrEmail) ||
            (document.getElementById("loginOrEmailOrPhone") && !loginOrEmailOrPhone) ||
            !password
        ) {
            throw new Error("Заполните обязательные поля!");
        }
        if (password !== passwordRepeat) {
            throw new Error("Пароли не совпадают!")
        }
    } 
    catch (Error) {
        event.preventDefault();
        ErrorMessage.textContent = `Ошибка: ${Error.message}`;
    }
});