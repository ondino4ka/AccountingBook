# AccountingBook
Project for Training Epam

Инструкция по запуску:

1) Для создания БД запустить скрипт AccountingBookDataBaseScripts\Database\initDataBase.sql (при необходимости запустить AccountingBookDataBaseScripts\UserscreateLoginName.sql - для создания имени входа на сервер)
2) Поменять connectionStrings в Service\AccountingBookService\Web.config.
3) Запустить Service\AccountingBookService через Visual Studio или развернуть на IIS.
4) Поменять адреса в Web\AccountingBookWeb.Web\Web.config на адрес развернутого сервиса.
Изменить адрес в Web\AccountingBookData\Service References.
5) Запустить Web\AccountingBookWeb через Visual Studio или развернуть на IIS.
6) Дать разрешение пулу сервиса на запись в папку.

Аккаунты для входа: name: kostya password: 123456 admin
                    name: maxim. password: 123456 moderator
