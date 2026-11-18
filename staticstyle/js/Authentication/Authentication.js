    document.querySelectorAll('.toggle-password').forEach(button => {
                button.addEventListener('click', () => {
                    const input = document.getElementById(button.dataset.target);
                    const isPassword = input.type === 'password';
                    input.type = isPassword ? 'text' : 'password';
                    button.textContent = isPassword ? '•' : '♦';
                    button.setAttribute('aria-label', isPassword ? 'Скрыть пароль' : 'Показать пароль');
                });
            });

            const ErrorMessage = document.getElementById("error");
            const Form = document.getElementById("form");

            Form.addEventListener("submit", (event) => {
                try {
                    ErrorMessage.textContent = "";

                    const login = document.getElementById("login").value.trim();
                    const phoneOrEmail = document.getElementById("phoneOrEmail").value.trim();
                    const password = document.getElementById("password").value.trim();
                    const passwordRepeat = document.getElementById("passwordRepeat").value.trim();

                    if (!login || !phoneOrEmail || !password) {
                        throw new Error("Заполните обязательные поля!");
                    }
                    if (password != passwordRepeat) {
                        throw new Error("Пароли не совпадают!")
                    }
                } 
                catch (Error) {
                    event.preventDefault();
                    ErrorMessage.textContent = `Ошибка: ${Error.message}`;
                }
            });