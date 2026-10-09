1.	/
•	Expect: 200 — HomeController.Index (default route)
2.	/Home/Privacy
•	Expect: 200 — HomeController.Privacy view exists
3.	/Playlist
•	Expect: 200 — PlaylistController.Index returns the songs list
4.	/find/koffee
•	Expect: 200 — catch-all Find handles letters-only, finds “Toast - Koffee”, shows “Play it” link to /track/{n}
5. /Playlist/Find/koffee
•	Expect: 404 — routing mismatch: Find has an attribute route at root ("find/{*term}"), so the conventional /Playlist/Find/... route does not exist (this URL would likely have worked if the action had no attribute route).
6.	/Home/Error
•	Expect: 404 — the Error action/view were removed, so the route no longer exists.
7.	/NoController/Index
•	Expect: 404 — no controller named NoController (missing controller).
