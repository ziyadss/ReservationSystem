<script>
    import logo from '$lib/images/logo.svg';
    import { page } from '$app/stores';
</script>

<section id="hero">
    <header class="header">
        <div class="container">
            <nav class="navigation">
                <a href="index.html" class="logo">
                    <img src={logo} alt="Logo" class="logo-img" />
                </a>
                <div class="mobile-menu-icon">
                    <ion-icon name="menu-outline" class="menu_icon"></ion-icon>
                </div>
                <ul class="nav_menu">
                    <li class="nav_list">
                        {#if $page.url.pathname === '/'}
                            <a href="/" class="nav_link active">Home</a>
                        {:else}
                            <a href="/" class="nav_link">Home</a>
                        {/if}
                    </li>
                    <li class="nav_list">
                        {#if $page.url.pathname === '/schedule'}
                            <a href="/schedule" class="nav_link active" target="_matches">Match Schedule </a>
                        {:else}
                            <a href="/schedule" class="nav_link" target="_matches">Match Schedule </a>
                        {/if}
                    </li>
                    <li class="nav_list btn-nav">
                        <a href="/login" class="btn-outline">
                            <span>Start your journey</span>
                            <iconify-icon icon="ri:compass-3-line"></iconify-icon>
                        </a>
                    </li>
                </ul>
            </nav>
        </div>
    </header>
</section>