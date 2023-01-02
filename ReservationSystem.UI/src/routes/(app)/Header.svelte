<script lang="js">
	import logo from '$lib/images/logo.svg';
	import { page } from '$app/stores';
	import { browser } from '$app/environment';
	import Swal from 'sweetalert2';
	import 'sweetalert2/src/sweetalert2.scss';

	let loggedin = false;
	if (browser) {
		loggedin = localStorage.getItem('token') ? true : false;
	}

	async function signOut() {
		if (browser) {
			window.localStorage.removeItem('token');
			window.localStorage.removeItem('role');
			await Swal.fire('Log Out!', 'You have been logged out.', 'success');
			window.location.replace('/');
		}
	}
</script>

<section id="hero">
	<header class="header">
		<div class="container">
			<nav class="navigation">
				<a href="/" class="logo">
					<img src={logo} alt="Logo" class="logo-img" />
				</a>
				<div class="mobile-menu-icon">
					<ion-icon name="menu-outline" class="menu_icon" />
				</div>
				<ul class="nav_menu">
					<li class="nav_list">
						{#if $page.url.pathname === '/'}
							<a href="/" class="nav_link active">Home</a>
						{:else}
							<a href="/" class="nav_link">Home</a>
						{/if}
					</li>
					{#if loggedin}
						<li class="nav_list">
							{#if $page.url.pathname === '/profile'}
								<a href="/profile" class="nav_link active">Profile</a>
							{:else}
								<a href="/profile" class="nav_link">Profile</a>
							{/if}
						</li>
					{/if}
					<li class="nav_list">
						{#if $page.url.pathname === '/schedule'}
							<a href="/schedule" class="nav_link active" target="_matches">Match Schedule </a>
						{:else}
							<a href="/schedule" class="nav_link" target="_matches">Match Schedule </a>
						{/if}
					</li>

					<li class="nav_list btn-nav">
						{#if loggedin}
							<a href="/" class="btn-outline" on:click={() => signOut()}>
								<span>Logout</span>
							</a>
						{:else}
							<a href="/login" class="btn-outline">
								<span>Start your journey</span>
								<iconify-icon icon="ri:compass-3-line" />
							</a>
						{/if}
					</li>
				</ul>
			</nav>
		</div>
	</header>
</section>
