<script>
	import { browser } from "$app/environment"
	import logo from '$lib/images/logo.svg';
	import cover from '$lib/images/cover-photo.jpg';
	import { onMount } from "svelte";
	import { redirect } from "@sveltejs/kit";
	import Swal from 'sweetalert2';
	import 'sweetalert2/src/sweetalert2.scss';

	let token = '';
	onMount(async () => {
		let _token;
		let _role;
		if (browser) {
			_token = window.localStorage.getItem('token');
			_role = window.localStorage.getItem('role');
		}

		if (_token) {
			if (_role == 'User') {
				window.location.replace('/');
			}
			else if (_role == 'Manager') {
				window.location.replace('/manager/match/list');
			}
			else if (_role == 'Admin') {
				window.location.replace('/admin/list');
			}
			token = _token;
		}
	});

	let user = {
		userName: '',
		password: ''
	};

	async function login() {
		const response = await fetch('https://localhost:7123/api/auth/login', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(
				user
			)
		});
		if (response.ok) {
			const data = await response.json();
			if (browser) {
				window.localStorage.setItem('token', data.token);
				window.localStorage.setItem('role', data.role);
			}
			if (data.role == 'User') {
				window.location.replace('/');
			}
			else if (data.role == 'Manager') {
				window.location.replace('/manager/match/list');
			}
			else if (data.role == 'Admin') {
				window.location.replace('/admin/list');
			}
		} else {
            Swal.fire(
            'Invalid!',
            'Invalid credentials.',
            'error'
            );
		}
	}
	//hide label on input
	function hideLabel() {
		const label = document.querySelector('#usernameLabel');
		if (user.userName.length > 0) {
			label?.setAttribute('style', 'display:none');
		} else if (user.userName.length == 0) {
			label?.setAttribute('style', 'display:block');
		}
		const label2 = document.querySelector('#passwordLabel');
		if (user.password.length > 0) {
			label2?.setAttribute('style', 'display:none');
		} else if (user.password.length == 0) {
			label2?.setAttribute('style', 'display:block');
		}
	}
</script>

<svelte:head>
	<title>Login & Start your journey!</title>
	<meta name="description" content="Qatar 2022&trade;" />
</svelte:head>


<section class="vh-100">
	<div class="container-fluid">
		<div class="row">
			<div class="col-sm-6 text-black">
				<div class="col-sm-4 p-5 ms-xl-4">
					<img src={logo} alt="logo" class="logo mb-5" />
				</div>
				<div class="col-sm-6 py-5" />
				<div
					class="row d-flex align-items-center justify-content-center h-custom-1 px-5 ms-xl-4 mt-5 pt-5 pt-xl-0 mt-xl-n5 align-self-center"
				>
					<div class="col-md-9">
						<form on:submit|preventDefault={login} class="my-5" id="login-form">
							<h3 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Log in</h3>

							<div class="form-outline mb-4">
								<input
									type="text"
									class="form-control form-control-lg"
									bind:value={user.userName}
									on:input={hideLabel}
								/>
								<label class="form-label" id="usernameLabel" for="form2Example18">Username</label>
							</div>

							<div class="form-outline mb-4">
								<input
									type="password"
									class="form-control form-control-lg"
									bind:value={user.password}
									on:input={hideLabel}
								/>
								<label class="form-label" id="passwordLabel" for="form2Example28">Password</label>
							</div>

							<div class="pt-1 mb-4">
								<button class="btn btn-info btn-lg btn-block" id="btn-main" type="submit"
									>Login</button
								>
							</div>

							<p class="small mb-5 pb-lg-2"><a class="text-muted" href="#!">Forgot password?</a></p>
							<p>Don't have an account? <a href="/register" class="link-info">Register here</a></p>
						</form>
					</div>
				</div>
			</div>
			<div class="col-sm-6 px-0 d-none d-sm-block">
				<img src={cover} alt="cover" class="w-100 vh-100" style="object-fit: cover; object-position: left;" />
			</div>
		</div>
	</div>
</section>