require 'read_output_helper'

`ruby ./spec/texttest_fixture.rb 30 > ./spec/actual_output.txt`

expected_output = read_output("./spec/expected_output.txt")
actual_output = read_output("./spec/actual_output.txt")

describe "#update_quality" do

  expected_output.each_with_index do |items, day_index|
    context "Day: #{day_index}" do
      items.each_with_index do |item, item_index|
        context "Item #{item_index + 1}: #{item[0]}" do
          it "sell_by should match" do
            expect(actual_output[day_index][item_index][1]).to eq expected_output[day_index][item_index][1]
          end
          it "quality should match" do
            expect(actual_output[day_index][item_index][2]).to eq expected_output[day_index][item_index][2]
          end
        end
      end
    end
  end
  
end