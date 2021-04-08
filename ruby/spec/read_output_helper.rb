def read_output(file_name)
  days = File.read(file_name).split("\n\n")
  days.map{ |day| day.split("\n")[2..].map { |items| items.split(",") } }
end