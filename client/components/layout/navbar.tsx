import Link from "next/link";
import { Button } from "@/components/ui/button";
import { Search, Bell } from "lucide-react";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Badge } from "@/components/ui/badge";

const Navbar = () => {
  // TODO: Replace with actual auth state
  const isAuthenticated = true;

  const notifications = [
    {
      id: 1,
      title: "New course available",
      message: "Advanced React Patterns course is now available",
      time: "5 mins ago",
      unread: true,
    },
    {
      id: 2,
      title: "Assignment due soon",
      message: "JavaScript Fundamentals assignment due in 2 days",
      time: "2 hours ago",
      unread: true,
    },
    {
      id: 3,
      title: "Course completed",
      message: "You've completed the Python Basics course",
      time: "1 day ago",
      unread: false,
    },
  ];

  return (
    <nav className="fixed w-full bg-white border-b z-50">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between h-16">
          <div className="flex items-center">
            <Link href="/" className="flex items-center">
              <span className="text-2xl font-bold text-primary">EduLearn</span>
            </Link>

            <div className="hidden md:flex items-center space-x-8 ml-10">
              <Link
                href="/courses"
                className="text-gray-600 hover:text-primary"
              >
                Courses
              </Link>
              <Link href="/about" className="text-gray-600 hover:text-primary">
                About
              </Link>
              <Link
                href="/contact"
                className="text-gray-600 hover:text-primary"
              >
                Contact
              </Link>
            </div>
          </div>

          <div className="flex items-center space-x-4">
            {isAuthenticated && (
              <>
                <Dialog>
                  <DialogTrigger asChild>
                    <Button variant="ghost" size="icon" className="relative">
                      <Bell className="h-5 w-5" />
                      <Badge
                        variant="destructive"
                        className="absolute -top-1 -right-1 h-5 w-5 flex items-center justify-center p-0"
                      >
                        2
                      </Badge>
                    </Button>
                  </DialogTrigger>
                  <DialogContent className="sm:max-w-[425px]">
                    <DialogHeader>
                      <DialogTitle>Notifications</DialogTitle>
                    </DialogHeader>
                    <div className="space-y-4 mt-4">
                      {notifications.map((notification) => (
                        <div
                          key={notification.id}
                          className={`p-4 rounded-lg ${
                            notification.unread ? "bg-muted" : ""
                          }`}
                        >
                          <h4 className="text-sm font-semibold">
                            {notification.title}
                          </h4>
                          <p className="text-sm text-muted-foreground mt-1">
                            {notification.message}
                          </p>
                          <p className="text-xs text-muted-foreground mt-2">
                            {notification.time}
                          </p>
                        </div>
                      ))}
                    </div>
                  </DialogContent>
                </Dialog>

                <Dialog>
                  <DialogTrigger asChild>
                    <Button variant="ghost" size="icon">
                      <Search className="h-5 w-5" />
                    </Button>
                  </DialogTrigger>
                  <DialogContent className="sm:max-w-[600px]">
                    <DialogHeader>
                      <DialogTitle>Search Courses</DialogTitle>
                    </DialogHeader>
                    <div className="space-y-4 mt-4">
                      <Input
                        type="search"
                        placeholder="Search for courses, lessons, or topics..."
                        className="w-full"
                      />
                      <div className="space-y-2">
                        <h3 className="text-sm font-medium">
                          Popular Searches
                        </h3>
                        <div className="flex flex-wrap gap-2">
                          {[
                            "React",
                            "JavaScript",
                            "Python",
                            "Web Development",
                          ].map((term) => (
                            <Button key={term} variant="secondary" size="sm">
                              {term}
                            </Button>
                          ))}
                        </div>
                      </div>
                    </div>
                  </DialogContent>
                </Dialog>
              </>
            )}

            {isAuthenticated ? (
              <DropdownMenu>
                <DropdownMenuTrigger asChild>
                  <Button
                    variant="ghost"
                    className="relative h-8 w-8 rounded-full"
                  >
                    <Avatar className="h-8 w-8">
                      <AvatarImage src="/avatars/user.png" alt="User" />
                      <AvatarFallback>U</AvatarFallback>
                    </Avatar>
                  </Button>
                </DropdownMenuTrigger>
                <DropdownMenuContent className="w-56" align="end" forceMount>
                  <DropdownMenuLabel className="font-normal">
                    <div className="flex flex-col space-y-1">
                      <p className="text-sm font-medium leading-none">
                        User Name
                      </p>
                      <p className="text-xs leading-none text-muted-foreground">
                        user@example.com
                      </p>
                    </div>
                  </DropdownMenuLabel>
                  <DropdownMenuSeparator />
                  <DropdownMenuItem asChild>
                    <Link href="/dashboard">Dashboard</Link>
                  </DropdownMenuItem>
                  <DropdownMenuItem asChild>
                    <Link href="/profile">Profile</Link>
                  </DropdownMenuItem>
                  <DropdownMenuItem asChild>
                    <Link href="/settings">Settings</Link>
                  </DropdownMenuItem>
                  <DropdownMenuSeparator />
                  <DropdownMenuItem>Log out</DropdownMenuItem>
                </DropdownMenuContent>
              </DropdownMenu>
            ) : (
              <div className="flex items-center space-x-2">
                <Button variant="ghost" asChild>
                  <Link href="/login">Sign In</Link>
                </Button>
                <Button asChild>
                  <Link href="/register">Get Started</Link>
                </Button>
              </div>
            )}
          </div>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
