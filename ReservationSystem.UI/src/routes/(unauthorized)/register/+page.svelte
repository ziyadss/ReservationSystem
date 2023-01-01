<script lang="js">
	import logo from '$lib/images/logo.svg';
	import { browser } from "$app/environment"
	import { enhance } from '$app/forms';
	import cover from '$lib/images/cover-photo.jpg';
	let date = new Date();
	let user = {
		userName: '',
		password: '',
		email: '',
		firstName: '',
		lastName: '',
		birthdate: date,
		gender: '',
		nationality: ''
	};

	async function registerUser() {
		const response = await fetch('https://localhost:7123/api/auth/register', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(
				user
			)
		});
		console.log(response);
		if (response.ok) {
			const data = await response.json();
			if (browser) window.localStorage.setItem('token', data.token);
			window.location.replace('/');
		} else {
			alert('Please enter a valid credentials');
		}
	}
</script>

<svelte:head>
	<title>Register!</title>
	<meta name="description" content="Qatar 2022&trade;" />
</svelte:head>


<section class="vh-100">
	<div class="container-fluid">
		<div class="row">
			<div class="col-sm-6 px-0 d-none d-sm-block">
				<img
					src={cover}
					alt="Login"
					class="w-100 vh-100"
					style="object-fit: cover; object-position: left;"
				/>
			</div>
			<div class="col-sm-6 text-black">
				<div class="col-sm-4 p-5 ms-xl-4">
					<img src={logo} alt="logo" class="logo mb-1" />
				</div>
				<div
					class="row d-flex align-items-center justify-content-center h-custom-1 px-5 ms-xl-4 mt-5 pt-5 pt-xl-0 mt-xl-n5 align-self-center"
				>
					<div class="col-md-9">
						<form on:submit|preventDefault={registerUser} id="login-form" use:enhance>
							<h3 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Register</h3>

							<div class="form-outline mb-4">
								<label class="input-title" id="usernameLabel" for="form2Example18">Username</label>
								<input
									type="text"
									class="form-control form-control-lg"
									name="userName"
									bind:value={user.userName}
									required
								/>
							</div>
							<div class="form-outline mb-4">
								<label class="input-title" id="usernameLabel" for="form2Example18">Email</label>
								<input type="text" name="email" class="form-control form-control-lg" bind:value={user.email} />
							</div>
							<div class="form-outline mb-4">
								<label class="input-title" id="passwordLabel" for="form2Example28">Password</label>
								<input
									type="password"
									class="form-control form-control-lg"
									name="password"
									bind:value={user.password}
									required
								/>
							</div>
							<div class="form-outline mb-4">
								<label class="input-title" id="passwordLabel" for="form2Example28">First Name</label
								>
								<input
									type="text"
									class="form-control form-control-lg"
									name="firstName"
									bind:value={user.firstName}
									required
								/>
							</div>
							<div class="form-outline mb-4">
								<label class="input-title" id="passwordLabel" for="form2Example28">Last Name</label>
								<input
									type="text"
									class="form-control form-control-lg"
									name="lastName"
									bind:value={user.lastName}
									required
								/>
							</div>
							<div class=" row mb-4">
								<div class="col form-outline">
									<label class="input-title" id="passwordLabel" for="form2Example28"
										>Birth Date</label
									>
									<input bind:value={user.birthdate} class="form-control form-control-lg" type="date" name="birthDate" />
								</div>
								<div class="col">
									<label class="input-title" for="form2Example28">Gender</label>
									<select class="form-control form-control-lg" bind:value={user.gender} required name="gender" style="border-radius: 1rem;font-size: 16px;padding: .32rem .75rem;border: none;">
										<option value="3">Female</option>
										<option value="2">Male</option>
										<option value="1">Unspecified</option>
										<option value="0">Unknown</option>
									</select>
								</div>
							</div>
							<div class="pt-1 mb-4">
								<button class="btn btn-info btn-lg btn-block" id="btn-main" type="submit"
									>Register</button
								>
							</div>
							<p>Already a member? <a href="/login" class="link-info">Login</a></p>
						</form>
					</div>
				</div>
			</div>
		</div>
	</div>
</section>