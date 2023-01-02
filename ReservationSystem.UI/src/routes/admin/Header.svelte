<script lang="js">
	import '../styles.css';
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

	$: currentURL = $page.url.pathname;
</script>

<nav class="navbar navbar-expand-lg navbar-light bg-light">
	<!-- Container wrapper -->
	<div class="container">
		<!-- Toggle button -->
		<button
			class="navbar-toggler"
			type="button"
			data-mdb-toggle="collapse"
			data-mdb-target="#navbarButtonsExample"
			aria-controls="navbarButtonsExample"
			aria-expanded="false"
			aria-label="Toggle navigation"
		>
			<i class="fas fa-bars" />
		</button>

		<!-- Collapsible wrapper -->
		<div class="collapse navbar-collapse" id="navbarButtonsExample">
			<!-- Left links -->

			<div class="d-flex align-items-center">
				<button
					type="button"
					class="btn btn-dark-outline px-3 me-2"
					style="box-shadow: none;"
					on:click={() => signOut()}
				>
					Logout
				</button>
			</div>
		</div>
		<!-- Collapsible wrapper -->
	</div>
	<!-- Container wrapper -->
</nav>
<!-- Navbar -->
