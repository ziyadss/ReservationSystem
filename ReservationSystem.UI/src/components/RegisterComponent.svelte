<script lang="js">
	import logo from '$lib/images/logo.svg';
	import { store } from '../hooks/auth';
	import cover from '../lib/images/cover-photo.jpg';
	import { DateInput } from 'date-picker-svelte';
	let date = new Date();
	let user = {
		username: '',
		password: '',
		firstname: '',
		lastname: '',
		birthdate: date,
		gender: '',
		nationality: '',
		email: ''
	};

	async function registerUser() {
		const response = await fetch('https://localhost:7123/api/auth/register', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({
				user
			})
		});
		console.log(response);
		console.log(user.username);
		console.log(JSON.stringify(user));
		if (response.ok) {
			const { user } = await response.json();
			window.location.replace('/login');
		} else {
			console.log(JSON.stringify(response.body));
			alert('Please enter a valid credentials');
		}
	}
</script>

<section class="vh-100">
	<div class="container-fluid">
		<div class="row">
			<div class="col-sm-6 px-0 d-none d-sm-block">
				<img
					src={cover}
					alt="Login image"
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
						<form on:submit|preventDefault={registerUser} id="login-form">
							<h3 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Register</h3>

							<div class="form-outline mb-4">
								<label class="input-title" id="usernameLabel" for="form2Example18">Username</label>
								<input
									type="text"
									class="form-control form-control-lg"
									bind:value={user.username}
									required
								/>
							</div>
							<div class="form-outline mb-4">
								<label class="input-title" id="usernameLabel" for="form2Example18">Email</label>
								<input type="text" class="form-control form-control-lg" bind:value={user.email} />
							</div>
							<div class="form-outline mb-4">
								<label class="input-title" id="passwordLabel" for="form2Example28">Password</label>
								<input
									type="password"
									class="form-control form-control-lg"
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
									bind:value={user.firstname}
									required
								/>
							</div>
							<div class="form-outline mb-4">
								<label class="input-title" id="passwordLabel" for="form2Example28">Last Name</label>
								<input
									type="text"
									class="form-control form-control-lg"
									bind:value={user.lastname}
									required
								/>
							</div>
							<div class=" row mb-4">
								<div class="col form-outline">
									<label class="input-title" id="passwordLabel" for="form2Example28"
										>Birth Date</label
									>
									<DateInput bind:value={date} format="yyyy-MM-dd" />
								</div>
								<div class="col">
									<label class="input-title" for="form2Example28">Gender</label>
									<select class="form-control form-control-lg" bind:value={user.gender} required>
										<option value="F">Female</option>
										<option value="M">Male</option>
										<option value="Other">Other</option>
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
<!-- <div class="container">
	<div class="row justify-content-center align-items-center py-5 vh-100">
		<div class="col-12 col-md-8 col-lg-6 col-xl-6 align-self-center">
			<form
				on:submit|preventDefault={registerUser}
				class="form-control shadow-lg p-4 px-5"
				id="login-form"
			>
				<div class="form-group py-2 px-3">
					<label for="username" class="input-title px-3">Username</label>
					<input
						type="text"
						class="form-control rounded-pill border-white p-3 px-3"
						placeholder="New username"
						style="background-color:#F4F6FB;"
						required
					/>
				</div>
				<div class="form-group py-2 px-3">
					<label for="title" class="input-title px-3">Password</label>
					<input
						type="password"
						class="form-control rounded-pill border-white p-3 px-3"
						placeholder="New Password"
						style="background-color:#F4F6FB;"
						required
					/>
				</div>
				<div class="justify-content-md-center py-4 px-3">
					<input
						type="submit"
						class="btn rounded-pill w-100 shadow-sm"
						value="Register"
						id="submitbutton"
					/>
				</div>
				<div class="py-2 text-center">
					<h3>
						Already registered? <a style="color:#2D2A5D;" href="/login">Log-in</a>
					</h3>
				</div>
			</form>
		</div>
	</div>
</div> -->
<!-- <div class="container">
	<div class="row justify-content-center m-3 shadow-lg">
		<div class="col-lg-4 p-5 " style="background-color: #8a1538;">
			<div class="row">
				<div class="col-2" />
				<div class="col-8" style="display: flex; justify-content: center;">
					<img src={logo} alt="logo" class="img-fluid mb-3" />
				</div>
				<div class="col-2" />
			</div>
			<div class="row mt-3">
				<div class="col" />
				<div class="col" />
				<div class="col" />
			</div>
		</div>
		<div class="col-lg-7 p-3">
			<div class="row text-center p-3 m-2">
				<h1 class="display-6 text-center">Welcome!</h1>
				<p class="lead text-center">Begin your journey here!</p>
			</div>
			<div class="row p-2 m-2 align-items-center">
				<div class="col" />
				<div class="col-9">
					<form class="form-control">
						<div class="form-group py-2">
							<label for="username">Username</label>
							<input
								type="text"
								class="form-control"
								id="username"
								name="username"
								placeholder="enter username"
								required
							/>
						</div>
						<div class="form-group py-2">
							<label for="registerpassword">Password</label>
							<input
								type="password"
								class="form-control"
								id="registerpassword"
								name="password"
								placeholder="enter password"
								required
							/>
						</div>
						<div class="form-group" style="display: flex; justify-content: center;">
							<input type="submit" class=" btn rounded-pill" id="btn-main" value="Register" />
						</div>
					</form>
				</div>
				<div class="col" />
			</div>
			<div class="row text-center p-2 m-2">
				<p class="lead text-center p-0 m-0">Already a user?</p>
				<a class="lead text-center p-0 m-0" href="/login">Log in</a>
			</div>
		</div>
	</div>
</div> -->
