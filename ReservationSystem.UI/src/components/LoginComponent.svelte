<script>
	import { store } from '../hooks/auth.js';
	import logo from '../lib/images/logo.svg';
	import cover from '../lib/images/cover-photo.jpg';

	let username = '';
	let password = '';

	async function login() {
		const response = await fetch('/api/auth/login', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({
				username,
				password
			})
		});
		console.log(response);
		console.log(username);
		console.log(password);
		if (response.ok) {
			const { user } = await response.json();
			store.set(user);
			window.location.replace('/');
		} else {
			alert('Invalid credentials');
		}
	}
	//hide label on input
	function hideLabel() {
		const label = document.querySelector('#usernameLabel');
		if (username.length > 0) {
			label?.setAttribute('style', 'display:none');
		} else if (username.length == 0) {
			label?.setAttribute('style', 'display:block');
		}
		const label2 = document.querySelector('#passwordLabel');
		if (password.length > 0) {
			label2?.setAttribute('style', 'display:none');
		} else if (username.length == 0) {
			label2?.setAttribute('style', 'display:block');
		}
	}
</script>

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
									bind:value={username}
									on:input={hideLabel}
								/>
								<label class="form-label" id="usernameLabel" for="form2Example18">Username</label>
							</div>

							<div class="form-outline mb-4">
								<input
									type="password"
									class="form-control form-control-lg"
									bind:value={password}
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
				<img
					src={cover}
					alt="Login image"
					class="w-100 vh-100"
					style="object-fit: cover; object-position: left;"
				/>
			</div>
		</div>
	</div>
</section>

<!-- <form on:submit|preventDefault={login} class="login-form flex mx-auto col-6">
    <div class="form-control">
        <label for="username">Username</label>
        <input type="text" id="username" bind:value={username} />
    </div>
    <div class="form-control">
        <label for="password">Password</label>
        <input type="password" id="password" bind:value={password} />
    </div>
    <button type="submit" class="btn-primary">Login</button>
</form> -->
<style>
	.bg-image-vertical {
		position: relative;
		overflow: hidden;
		background-repeat: no-repeat;
		background-position: right center;
		background-size: auto 100%;
	}

	@media (min-width: 1025px) {
		.h-custom-2 {
			height: 100%;
		}
	}
</style>
