document.addEventListener('DOMContentLoaded', () => {
    let menu = document.querySelector('.nav_menu');
    let menu_toggle = document.querySelector('.mobile-menu-icon');
    let menu_toggle_icon = document.querySelector('.mobile-menu-icon ion-icon');
    menu_toggle?.addEventListener('click', () => {
        menu?.classList.toggle('active');
        menu?.classList.contains('active') ?
            menu_toggle_icon?.setAttribute('name', 'close-outline') :
            menu_toggle_icon?.setAttribute('name', 'menu-outline');
    });
});